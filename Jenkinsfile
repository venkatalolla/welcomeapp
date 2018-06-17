#!groovy

node('test')
{
    stage('Checkout Source')
    {
      git changelog: false, poll: false, url: 'https://github.com/venkatalolla/welcomeapp.git'
    }

    stage('Build')
    {
        sh "cd welcomeapp"
        sh "dotnet restore"
    }

    /*stage('Unit Tests')
    {
        echo "Unit Tests"
        sh "${mvnCmd} test"
    }

    stage('Code Analysis')
    {
        echo "Code Analysis"
        //sh "${mvnCmd} sonar:sonar -Dsonar.host.url=http://sonarqube.sonarqube.svc.cluster.local:9000/ -Dsonar.projectName=${JOB_BASE_NAME}"
        sh "${mvnCmd} org.sonarsource.scanner.maven:sonar-maven-plugin:3.2:sonar -Dsonar.host.url=http://sonarqube.sonarqube.svc.cluster.local:9000/ -Dsonar.projectName=${JOB_BASE_NAME}"
    }

    stage('Publish to Artifactory')
    {
        echo "Publish to Artifactory"

        // Replace xyz-nexus with the name of your project
        sh "${mvnCmd} deploy -DskipTests=true -DaltDeploymentRepository=nexus::default::http://nexus3.nexus.svc.cluster.local:8081/repository/releases"

        // Get Repository from GitHub
        git url: 'https://github.com/cjsrinivas/openshift-tasks-ocp.git'

        // Create war file name from pom.xml properties
        String warFileName = "${groupId}.${artifactId}"
        warFileName = warFileName.replace('.', '/')
        sh "echo ${warFileName}/${version}/${artifactId}-${version}.war"

        // Update the .s2i/environment file with the location of the latest war file name
        // Also add Build Number so that every build we get a unique environment file and
        // The git commit/push step succeeds.
        sh "echo WAR_FILE_LOCATION=http://nexus3.nexus.svc.cluster.local:8081/repository/releases/${warFileName}/${version}/${artifactId}-${version}.war > .s2i/environment"
        sh "echo BUILD_NUMBER=${BUILD_NUMBER} >>.s2i/environment"

        // Update the Git/Gogs repository with the latest file
        def commit = "Release " + version
        withCredentials([string(credentialsId: 'gitid', variable: 'TOKEN')])
        //withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'gitid', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
        {
            //available as an env variable, but will be masked if you try to print it out any which way
            sh "git config --global user.email 'cjsrinivas@gmail.com' && git config --global user.name 'Srinivas Coimbatore'"
            sh "git add .s2i/environment && git commit -m \"${commit}\""
            //sh "git push https://${env.USERNAME}:${env.PASSWORD}@github.com/cjsrinivas/openshift-tasks-ocp.git"
            sh "git push https://${env.TOKEN}@github.com/cjsrinivas/openshift-tasks-ocp.git"
        }
    }

    stage('Build OpenShift Image')
    {
        def newTag = "TestingCandidate-${version}"
        echo "New Tag: ${newTag}"
        openshiftBuild bldCfg: 'tasks', checkForTriggeredDeployments:'false', namespace: 'tasks-dev', showBuildLogs: 'false', verbose: 'false', waitTime: '', waitUnit: 'sec'
        openshiftVerifyBuild bldCfg: 'tasks', checkForTriggeredDeployments: 'false', namespace: 'tasks-dev', verbose: 'false', waitTime: ''
        openshiftTag alias: 'false', destStream: 'tasks', destTag:newTag, destinationNamespace: 'tasks-dev', namespace:'tasks-dev', srcStream: 'tasks', srcTag: 'latest', verbose:'false'
    }

    stage('Deploy to Dev')
    {
        // Patch the DeploymentConfig so that it points to the latest TestingCandidate-${version} Image.
        sh "oc project tasks-dev"
        sh "oc patch dc tasks --patch '{\"spec\": { \"triggers\": [ {\"type\": \"ImageChange\", \"imageChangeParams\": {\"containerNames\": [ \"tasks\" ], \"from\": { \"kind\":\"ImageStreamTag\", \"namespace\": \"tasks-dev\", \"name\":\"tasks:TestingCandidate-$version\"}}}]}}' -n tasks-dev"
        openshiftDeploy depCfg: 'tasks', namespace: 'tasks-dev', verbose: 'false', waitTime: '', waitUnit: 'sec'
        openshiftVerifyDeployment depCfg: 'tasks', namespace:'tasks-dev', replicaCount: '1', verbose: 'false', verifyReplicaCount: 'false', waitTime: '', waitUnit: 'sec'
        openshiftVerifyService namespace: 'tasks-dev', svcName:'tasks', verbose: 'false'
    }

    stage('Integration Test')
    {
        // Could use the OpenShift-Tasks REST APIs to make sure it is working as expected.
        def newTag = "ProdReady-${version}"
        echo "New Tag: ${newTag}"
        openshiftTag alias: 'false', destStream: 'tasks', destTag: newTag, destinationNamespace: 'tasks-dev', namespace: 'tasks-dev', srcStream: 'tasks', srcTag: 'latest', verbose: 'false'
    }

    // Blue/Green Deployment into Production
    // -------------------------------------
    def dest   = "tasks-green"
    def active = ""
    stage('Prep Production Deployment')
    {
        sh "oc project tasks-prod"
        sh "oc get route tasks -n tasks-prod -o jsonpath='{.spec.to.name }' > activesvc.txt"
        active = readFile('activesvc.txt').trim()
        if (active == "tasks-green")
        {
            dest = "tasks-blue"
        }
        echo "Active svc: " + active
        echo "Dest svc:   " + dest
    }

    stage('Deploy new Version')
    {
        echo "Deploying to ${dest}"
        // Patch the DeploymentConfig so that it points to
        // the latest ProdReady-${version} Image.
        echo "Updating deployment configuration and waiting 15 seconds for the update to complete"
        sh "oc patch dc ${dest} --patch '{\"spec\": { \"triggers\": [ {\"type\": \"ImageChange\", \"imageChangeParams\": {\"containerNames\": [ \"$dest\" ], \"from\": { \"kind\":\"ImageStreamTag\", \"namespace\": \"tasks-dev\", \"name\":\"tasks:ProdReady-$version\"}}}]}}' -n tasks-prod"
        openshiftDeploy depCfg: dest, namespace: 'tasks-prod', verbose: 'false', waitTime: '', waitUnit: 'sec'
        openshiftVerifyDeployment depCfg: dest, namespace: 'tasks-prod', replicaCount: '1', verbose: 'false', verifyReplicaCount: 'true', waitTime: '', waitUnit: 'sec'
    }

    stage('Switch over to new Version')
    {
        sh 'oc patch route tasks -n tasks-prod -p \'{"spec":{"to":{"name":"' + dest + '"}}}\''
        sh 'oc get route tasks -n tasks-prod > oc_out.txt'
        oc_out = readFile('oc_out.txt')
        echo "Current route configuration: " + oc_out
    }*/
}

// Convenience Functions to read variables from the pom.xml
def getVersionFromPom(pom)
{
    def matcher = readFile(pom) =~ '<version>(.+)</version>'
    matcher ? matcher[0][1] : null
}

def getGroupIdFromPom(pom)
{
    def matcher = readFile(pom) =~ '<groupId>(.+)</groupId>'
    matcher ? matcher[0][1] : null
}

def getArtifactIdFromPom(pom)
{
    def matcher = readFile(pom) =~ '<artifactId>(.+)</artifactId>'
    matcher ? matcher[0][1] : null
}
